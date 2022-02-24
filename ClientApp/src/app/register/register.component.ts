import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegister = new EventEmitter();
  registerForm!: FormGroup;
  validationErrors: string[] = [];

  constructor(private accountService: AccountService,
              private toastr: ToastrService,
              private fb: FormBuilder,
              private router: Router) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      gender: ['male'],
      knownAs: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
      confirmPassword: ['', [Validators.required, this.matchValues('password')]]
    })
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      const controls = control?.parent?.controls as { [key: string]: AbstractControl; };
      let matchToControl = null;    
      if(controls) matchToControl = controls[matchTo];       
      return control?.value === matchToControl?.value
        ? null : { isMatching: true }
    }
  }

  register(){
    this.accountService.register(this.registerForm.value).subscribe(response =>{
      this.router.navigateByUrl('/members');
    }, error => {
      this.validationErrors = error;
    })
  }

  cancel(){
    this.cancelRegister.emit(false);
  }

}
