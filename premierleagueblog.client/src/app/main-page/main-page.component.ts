import { Component, OnInit } from '@angular/core';
import { ArticleService } from '../article/article.service';
import { Article } from '../article/article';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {
  latestArticle?: Article;
  lastArticles: Article[] = [];

  constructor(private articleService: ArticleService) { }

  ngOnInit(){
    this.loadData();
  }

  loadData(){
    this.articleService.getData().subscribe({
      next: (result) => {
        if (result && result.totalCount > 0) {
          this.latestArticle = result.articles[0];
          this.lastArticles = result.articles.slice(1, result.totalCount);
        }
      },
      error: (err) => {
        console.error('Error fetching articles:', err);
      }
    });
  }

  getImagePath(image: string): string {
    return `/assets/images/${image}`;
  }

  groupArticles(articles: Article[], groupSize: number): Article[][] {
    const groups = [];
    for (let i = 0; i < articles.length; i += groupSize) {
      groups.push(articles.slice(i, i + groupSize));
    }
    return groups;
  }
}
