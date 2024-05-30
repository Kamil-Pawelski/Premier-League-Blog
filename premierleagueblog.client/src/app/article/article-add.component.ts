import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ArticleService } from './article.service';
import { Article } from './article';
import { Router } from '@angular/router';

@Component({
  selector: 'app-article-add',
  templateUrl: './article-add.component.html',
  styleUrl: './article-add.component.scss'
})
export class ArticleAddComponent implements OnInit {

  form!: FormGroup;

  constructor(
    private articleService: ArticleService,
    private router: Router
  ) { }

  ngOnInit(){
    this.form = new FormGroup({
      image: new FormControl('', Validators.required),
      title: new FormControl('', Validators.required),
      summary: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required)
    })
  }


  onSubmit() {
    if (this.form.valid) {
      let newArticle = <Article>{};
      newArticle.image = this.form.controls['image'].value;
      newArticle.title = this.form.controls['title'].value;
      newArticle.summary = this.form.controls['summary'].value;
      newArticle.description = this.form.controls['description'].value;

      this.articleService.post(newArticle).subscribe({
        next: () => {
          console.log(`Article has been created.`);
          this.router.navigate(['/']);
        },
        error: (error) => console.error(error)
      });
    }
  }
}
