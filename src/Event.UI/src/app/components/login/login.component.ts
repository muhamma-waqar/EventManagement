import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, FormsModule, NgForm, ReactiveFormsModule, Validators } from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import {MatCardContent, MatCardModule} from '@angular/material/card';
import { ErrorStateMatcher } from '@angular/material/core';
import {MatFormFieldModule} from '@angular/material/form-field'
import {MatInputModule} from '@angular/material/input'
import { LoginService } from '../../services/login.service';
import { LoginResponseDto } from '../../Dtos/LoginResponseDto';
import {HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatButtonModule,
    CommonModule,
     MatCardModule, 
     MatCardContent,
     FormsModule, 
     MatFormFieldModule, 
     MatInputModule, 
     ReactiveFormsModule, 
     HttpClientModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent  implements OnInit{
  loginForm: FormGroup;
private loginResponse = new LoginResponseDto
  constructor(private fb: FormBuilder, private loginService : LoginService , private router : Router){
    this.loginForm = fb.group({
      email:['',[Validators.required, Validators.email]],
      password:['',[Validators.required]]
    })
  }

  ngOnInit(): void {
    console.log(this.loginResponse.accessToken);
  }

  onSubmit(){
    if(this.loginForm.valid){
      var {email,password} = this.loginForm.value
      this.loginService.login(email,password).subscribe(
        (response) =>{
        this.loginResponse = response
        console.log(response)
        this.router.navigateByUrl('menu')
      },
      (error) =>{
        console.log('login failed',error);
        this.router.navigateByUrl('menu')
      })
    }
  }
}
