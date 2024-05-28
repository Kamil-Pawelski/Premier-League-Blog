import { Component, OnInit } from '@angular/core';
import { Article } from './article';
import { ArticleService } from './article.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrl: './article.component.scss'
})
export class ArticleComponent implements OnInit {

  article?: Article;

  id?: number;

  form!: FormGroup;

  editMode: boolean = false;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private articleService: ArticleService
  ) { }

  ngOnInit() {
    this.form = new FormGroup({
      image: new FormControl('', Validators.required),
      title: new FormControl('', Validators.required),
      summary: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required)
    })
    this.loadData();
  }

  loadData() {
    var idParam = this.activatedRoute.snapshot.paramMap.get('id');
    this.id = idParam ? +idParam : 0;
    if (this.id) {
      this.articleService
        .get(this.id)
        .subscribe({
        next: (result) => {
          this.article = result;
          this.form.patchValue(this.article);
        },
        error: (error) => console.error(error)
      });
    }
  }

  editData() {
    this.editMode = !this.editMode;
  }

  onSubmit() {
    if (this.form.valid) {
      const updatedArticle: Article = this.id ? { ...this.article, ...this.form.value } : { ...this.form.value };
      this.articleService.put(updatedArticle).subscribe({
        next: () => {
          console.log(`Article ${updatedArticle.id} has been updated.`);
          this.article = updatedArticle;
          this.editMode = false;
        },
        error: (error) => console.error(error)
      });
    }
  }

  deleteArticle() {
    if (this.id) {
      this.articleService
        .delete(this.id)
        .subscribe({
          next: () => {
            console.log(`Article ${this.article!.id} has been deleted.`);
            this.router.navigate(['/']);
          }
        })
    }
  }

  getImagePath(image: string): string {
    return `/assets/images/${image}`;
  }
}
