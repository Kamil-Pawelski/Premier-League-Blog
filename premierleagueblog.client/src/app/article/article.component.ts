import { Component, OnInit } from '@angular/core';
import { Article } from './article';
import { ArticleService } from './article.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrl: './article.component.scss'
})
export class ArticleComponent  implements OnInit{

  article?: Article;

  id?: number;
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private articleService: ArticleService
  ) { }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    var idParam = this.activatedRoute.snapshot.paramMap.get('id');
    this.id = idParam ? +idParam : 0;

    if (this.id) {
      this.articleService.get(this.id).subscribe({
        next: (result) => {
          this.article = result;
        },
        error: (error) => console.error(error)
      });
    }
  }

  getImagePath(image: string): string {
    return `/assets/images/${image}`;
  }
}
