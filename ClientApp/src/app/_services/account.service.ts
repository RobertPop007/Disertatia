import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, pipe, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { PresenceService } from './presence.service';
import { ResetPasswordModel } from 'model/resetPasswordModel';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private presence: PresenceService) { }

  login(model: any){
    return this.http.post<User>(this.baseUrl + 'Account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if(user){
          this.setCurrentUser(user);
          this.presence.createHubConnection(user);
        }
      })
    );
  }

  subscribe(username: string){
    return this.http.post(this.baseUrl + 'Account/newsletter/' + username, '').subscribe();
  }

  enableDarkMode(username: string){
    return this.http.post(this.baseUrl + 'Account/darkMode/' + username, '').subscribe();
  }

  deleteAccount(username: string){
    return this.http.delete(this.baseUrl + 'Account/deleteUser/' + username).subscribe();
  }

  resetPassword(result: ResetPasswordModel){
    return this.http.post(this.baseUrl + 'Account/reset-password', result)
  }

  resetPasswordEmail(){
    return this.http.post(this.baseUrl + 'Account/forgotPassword', '')
  }

  setCurrentUser(user: User){
    user.roles = [];
    const roles = this.getDecodedToken(user.token).role;
    Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);

    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
   }

  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null!);
    this.presence.stopHubConnection();
  }

  register(model: any){
    return this.http.post(this.baseUrl + 'Account/register', model).pipe(
      map((user: User | any) => {
        if(user){
          this.setCurrentUser(user);
          this.presence.createHubConnection(user);
        }
      })
    )
  }

  getDecodedToken(token: string){
    return JSON.parse(atob(token.split('.')[1]));
  }

  LoginWithFacebook(credentials: string): Observable<any>{
    const header = new HttpHeaders().set('Content-type', 'application/json');
    return this.http.post(this.baseUrl + "Account/LoginWithFacebook", JSON.stringify(credentials), {headers: header, withCredentials: true});
  }
}
