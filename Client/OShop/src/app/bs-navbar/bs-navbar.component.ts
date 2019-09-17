import { AuthGuard } from './../auth/auth.guard';
import { AuthService } from './../auth/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'bs-navbar',
  templateUrl: './bs-navbar.component.html',
  styleUrls: ['./bs-navbar.component.css']
})
export class BsNavbarComponent implements OnInit {
  public isAdmin;
  constructor(private service: AuthService, public authGard: AuthGuard) { }

  ngOnInit() {

   }

  onLogout() {
    this.service.logout();
  }
}
