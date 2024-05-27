import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Article } from '../models/article';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root'
})
export class MainPageService extends BaseService<Article> {
  constructor(
    http: HttpClient
  ) { super(http); }

  getData(): Observable<ArticlesResponse> {
    const url = this.getUrl('api/Articles/Seven');
    return this.http.get<ArticlesResponse>(url);
  }

  get(id: number): Observable<Article> {
    var url = this.getUrl("api/Articles/" + id);
    return this.http.get<Article>(url);
  }

  put(item: Article): Observable<Article> {
    var url = this.getUrl("api/Articles/" + item.id);
    return this.http.put<Article>(url, item);
  }

  post(item: Article): Observable<Article> {
    var url = this.getUrl("api/Articles");
    return this.http.post<Article>(url, item);
  }
}

interface ArticlesResponse {
  totalCount: number;
  articles: Article[];
}
