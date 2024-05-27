import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';
import { ArticleComponent } from './article/article.component';
const routes: Routes = [
  { path: '', component: MainPageComponent, pathMatch: 'full' },
  { path: 'article/:id', component: ArticleComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
