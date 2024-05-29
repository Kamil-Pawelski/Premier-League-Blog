import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Login } from './login';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { LoginResult } from './login-result';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {

  loginResult?: LoginResult;

  form!: FormGroup;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private authService: AuthService) {

  }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.form = new FormGroup({
      email: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    let loginRequest = <Login>{};
    loginRequest.email = this.form.controls['email'].value;
    loginRequest.password = this.form.controls['password'].value;

    this.authService
      .login(loginRequest)
      .subscribe({
        next: (result) => {
          console.log(result);
          this.loginResult = result;
          if (result.success) {
            let returnUrl = this.activatedRoute.snapshot.queryParamMap.get('returnUrl') || '/';
            this.router.navigateByUrl(returnUrl);
          }
        },
        error: (error) => {
          console.log(error);
          if (error.status == 401) {
            this.loginResult = error.error;
          }
        }
      });
  }

}
