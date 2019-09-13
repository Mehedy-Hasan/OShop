import { AuthService } from './../../auth/auth.service';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styles: []
})
export class SignInComponent implements OnInit {

  formModel = {
    username: '',
    password: ''
  };
  constructor(private service: AuthService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    if (localStorage.getItem('token') != null) {
      this.router.navigate(['/home']);
    }
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/home');
        // tslint:disable-next-line: deprecation
        location.reload(true);
      },
      err => {
        // tslint:disable-next-line: triple-equals
        if (err.status == 400) {
          this.toastr.error('Incorrect Username or Password' , 'Authentication failed');
        } else {
          console.log(err);
        }

      }
    );
  }

}
