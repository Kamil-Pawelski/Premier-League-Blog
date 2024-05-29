import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { Register } from './register';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {

  form!: FormGroup;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
    private formBuilder: FormBuilder) {

  }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.form = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      confirmPassword: ['', [Validators.required]]
    }, { validator: this.passwordMatchValidator });
  }

  passwordMatchValidator(form: FormGroup) {
    const password = form.get('password')?.value;
    const confirmPassword = form.get('confirmPassword')?.value;
    return password === confirmPassword ? null : { mismatch: true };
  }

  onSubmit() {
    let registerRequest = <Register>{};
    registerRequest.email = this.form.controls['email'].value;
    registerRequest.password = this.form.controls['password'].value;

    this.authService.register(registerRequest).subscribe({
      next: () => {
        this.router.navigate(['/login']);
      },
      error: (error) => {
        console.log(error);
      }
    }
    );
  }
}
