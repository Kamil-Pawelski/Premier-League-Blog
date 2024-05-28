import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Login } from './login';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {

  login?: Login;

  form!: FormGroup;

  constructor(
    activatedRoute: ActivatedRoute,
    router: Router,
    private authService: AuthService) {

  }

  ngOnInit() {
    this.loadData();
  }

  loadData() {

  }

  onSubmit() {
    console.log("Test submit");
  }

}
