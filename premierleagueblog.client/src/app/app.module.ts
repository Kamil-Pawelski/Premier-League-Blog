import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AngularMaterialModule } from './angular-material.module';
import { MainPageComponent } from './main-page/main-page.component';
import { ArticleComponent } from './article/article.component';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { RegisterComponent } from './register/register.component';
import { ArticleAddComponent } from './article/article-add.component';
import { AllArticleComponent } from './article/all-article.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    MainPageComponent,
    ArticleComponent,
    LoginComponent,
    RegisterComponent,
    ArticleAddComponent,
    AllArticleComponent  
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    AngularMaterialModule,
    ReactiveFormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
