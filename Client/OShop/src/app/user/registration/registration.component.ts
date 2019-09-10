import { UserService } from './../../Shared/user.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: []
})
export class RegistrationComponent implements OnInit {

  constructor(public service: UserService, private toaster: ToastrService) { }

  ngOnInit() {
    this.service.formModel.reset();
  }
  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          this.toaster.success('New user created', 'User Registration');
        } else {
        res.errors.forEach(element => {
          switch (element.code) {
            case 'DuplicateUserName':
              this.toaster.error('Username is already taken', 'Registration failed');
              break;

            default:
              this.toaster.error(element.description, 'Registration failed');
              break;
          }
        });
        }
      },
      err => {
        console.log(err);
      }
    );
  }

}
