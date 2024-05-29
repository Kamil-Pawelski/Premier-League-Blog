import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';

import { environment } from './../../environments/environment';
import { LoginResult } from '../login/login-result';
import { Login } from '../login/login';
import { jwtDecode } from 'jwt-decode';
import { Register } from '../register/register';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    protected http: HttpClient) {
  }

  private tokenKey: string = "token";

  private _authStatus = new BehaviorSubject<boolean>(false);
  public authStatus = this._authStatus.asObservable();

  isAuthenticated(): boolean {
    return this.getToken() !== null;
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  init(): void {
    if (this.isAuthenticated())
      this.setAuthStatus(true);
  }

  login(item: Login): Observable<LoginResult> {
    var url = environment.baseUrl + "api/Account/Login";
    return this.http.post<LoginResult>(url, item)
      .pipe(tap(loginResult => {
        if (loginResult.success && loginResult.token) {
          localStorage.setItem(this.tokenKey, loginResult.token);
          this.setAuthStatus(true);
        }
      }));
  }

  register(item: Register): Observable<any> {
    var url = environment.baseUrl + "api/Account/Register";
    return this.http.post<Register>(url, item)
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
    this.setAuthStatus(false);
  }

  isAdmin(): boolean {
    const token = this.getToken();
    if (!token)
      return false;

    const decodedToken: any = jwtDecode(token);
    return decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"].includes('Administrator');
  }

  private setAuthStatus(isAuthenticated: boolean): void {
    this._authStatus.next(isAuthenticated);
  }
}
