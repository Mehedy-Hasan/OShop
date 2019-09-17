import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  userDetails$: Observable<any>;

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router, private route: ActivatedRoute) {
    this.userDetails$ = this.getUserProfile();
   }
  readonly baseURI = 'http://localhost:60841/api/';

  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, {validators: this.comparePasswords})
  });

  comparePasswords(fb: FormGroup) {
    const confirmPswrdCtrl = fb.get('ConfirmPassword');
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      // tslint:disable-next-line: triple-equals
      if (fb.get('Password').value != confirmPswrdCtrl.value) {
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      } else {
        confirmPswrdCtrl.setErrors(null);
      }
    }
  }

  register() {
    const body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.baseURI + 'ApplicationUser/Resister', body);
  }

  login(formData) {
    // tslint:disable-next-line: no-unused-expression
    let returnUrl = this.route.snapshot.queryParamMap.get('returnUrl') || '/';
    localStorage.setItem('returnUrl', returnUrl);

    return this.http.post(this.baseURI + 'ApplicationUser/login', formData);
  }

  logout(){
    localStorage.removeItem('token');
    this.router.navigate(['/']);
    // tslint:disable-next-line: deprecation
    location.reload(true);
  }

  getUserProfile() {
    return this.http.get(this.baseURI + 'UserProfile');
  }

  roleMatch(allowedRoles): boolean {
    let isMatch = false;
    let payload = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
    let userRole = payload.role;
    let roles = userRole;
    allowedRoles.forEach(element => {
      if (userRole == element) {
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }


}
