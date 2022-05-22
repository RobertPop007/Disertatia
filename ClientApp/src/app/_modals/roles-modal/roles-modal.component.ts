import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { User } from 'src/app/_models/user';
import {EventEmitter } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-roles-modal',
  templateUrl: './roles-modal.component.html',
  styleUrls: ['./roles-modal.component.css']
})
export class RolesModalComponent implements OnInit {
  @Input() updateSelectedRoles = new EventEmitter();
  user!: User;
  role: any = '';
  roles!: any[];

  constructor(public bsModalRef: BsModalRef,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  updateRoles(){
    const x = <HTMLInputElement>document.getElementById("Member");
    const y = <HTMLInputElement>document.getElementById("Moderator");
 
    if (!(y.checked && x.checked)){
    this.updateSelectedRoles.emit(this.roles as any);
    this.bsModalRef.hide();
    }
    else{
      this.toastr.error("Can't select more roles")
    }
  }
}
