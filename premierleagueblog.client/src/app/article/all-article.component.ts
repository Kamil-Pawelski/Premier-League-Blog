import { Component, OnInit } from '@angular/core';
import { ArticleService } from './article.service';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-all-article',
  templateUrl: './all-article.component.html',
  styleUrls: ['./all-article.component.scss']
})
export class AllArticleComponent implements OnInit {
  articles: any[] = [];
  totalArticles: number = 0;
  pageSize: number = 10;
  currentPage: number = 0;

  constructor(private articleService: ArticleService) { }

  ngOnInit() {
    this.loadData({ pageIndex: 0, pageSize: this.pageSize } as PageEvent);
  }

  loadData(event: PageEvent) {
    this.currentPage = event.pageIndex;
    this.pageSize = event.pageSize;

    this.articleService.getArticles(this.currentPage)
      .subscribe({
        next: (result) => {
          this.articles = result.articles;
          this.totalArticles = result.totalCount;
        },
      });
    console.log(this.totalArticles)
  }

  onPageChange(event: PageEvent) {
    this.loadData(event);

  }

  getImagePath(image: string): string {
    return `/assets/images/${image}`;
  }
}
