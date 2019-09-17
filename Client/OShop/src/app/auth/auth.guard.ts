import { AuthService } from './auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private service: AuthService) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean  {
      if (localStorage.getItem('token') != null) {
        let roles = next.data['permittedRoles'] as Array<String>;
        if (roles) {
          if (this.service.roleMatch(roles)) {
            return true;
          } else {
            this.router.navigate(['/forbidden']);
            return false;
          }
        } else{

          return true;
        }
      } else {
        this.router.navigate(['/user/signin'], {queryParams: { returnUrl: state.url }});
        return false;
      }
  }
}
