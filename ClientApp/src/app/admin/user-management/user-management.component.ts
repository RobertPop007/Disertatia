import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { initialState } from 'ngx-bootstrap/timepicker/reducer/timepicker.reducer';
import { ConfirmDialogComponent } from 'src/app/confirm-dialog/confirm-dialog.component';
import { RolesModalComponent } from 'src/app/_modals/roles-modal/roles-modal.component';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css']
})
export class UserManagementComponent implements OnInit {
  users!: Partial<User[]>;
  bsModalRef!: BsModalRef;

  constructor(private adminService: AdminService, 
    private modalService: BsModalService,
    public dialog: MatDialog,
    private router: Router,
    private accountAngularService: AccountService) { }

  ngOnInit(): void {
    this.getUserWithRoles();
  }

  getUserWithRoles(){
    this.adminService.getUserWithRoles().subscribe(users => {
      this.users = users;
    })
  }

  openRolesModal(user: User){
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        user,
        roles: this.getRolesArray(user)
      }
    }
    this.bsModalRef = this.modalService.show(RolesModalComponent, config);
    this.bsModalRef.content.updateSelectedRoles.subscribe((values: any[]) => {
      const rolesToUpdate = {
        roles: [...values.filter(el => el.checked === true).map(el => el.name)]
      };

      if(rolesToUpdate){
        this.adminService.updateUserRoles(user.username, rolesToUpdate.roles).subscribe(() => {
          user.roles = [...rolesToUpdate.roles]
        })
      }
    })
  }

  openRolesModalForModerator(user: User){
    
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        user,
        roles: this.getRolesArrayForModerator(user)
      }
    }
    this.bsModalRef = this.modalService.show(RolesModalComponent, config);
    this.bsModalRef.content.updateSelectedRoles.subscribe((values: any[]) => {

      const rolesToUpdate = {
        roles: [...values.filter(el => el.checked === true).map(el => el.name)]
      };

      let resetRoles: boolean = true;

      config.initialState.roles.forEach(element => {
        if(element.value === "Member"){
           resetRoles = false;
        }
      });

      if(resetRoles === true){
        rolesToUpdate.roles.forEach(element => {
          if(element === "Member"){
            rolesToUpdate.roles.splice(0, rolesToUpdate.roles.length);
            rolesToUpdate.roles.push("Member");
          }
        });
      }

      if(rolesToUpdate){
        this.adminService.updateUserRoles(user.username, rolesToUpdate.roles).subscribe(() => {
          user.roles = [...rolesToUpdate.roles]
        })
      }
    })
  }

  private getRolesArray(user: any){
    const roles: any[] = [];
    const userRoles = user.roles;
    const availableRoles: any[] = [
      {name: 'Admin', value: 'Admin'},
      {name: 'Moderator', value: 'Moderator'},
      {name: 'Member', value: 'Member'},
    ];

    availableRoles.forEach(role => {
      let isMatch = false;

      for(const userRole of userRoles){
        if(role.name === userRole){
          isMatch = true;
          role.checked = true;
          roles.push(role);
          break;
        }
      }

      if(!isMatch){
        role.checked = false;
        roles.push(role);
      }
    })
    return roles;
  }

  private getRolesArrayForModerator(user: any){
    const roles: any[] = [];
    const userRoles = user.roles;
    const availableRoles: any[] = [
      {name: 'Moderator', value: 'Moderator'},
      {name: 'Member', value: 'Member'},
    ];
    console.log(userRoles);
    
    availableRoles.forEach(role => {
      let isMatch = false;

      for(const userRole of userRoles){
        
        if(role.name === userRole){
          isMatch = true;
          role.checked = true;
          roles.push(role);
          break;
        }
      }

      if(!isMatch){
        role.checked = false;
        roles.push(role);
      }
    })
    return roles;
  }

  deleteAccount(username: string){
    const confirmDialog = this.dialog.open(ConfirmDialogComponent, {
      data: {
        title: "Confirm",
        message: "Are you sure you want to delete " + username + "?"
      }
    })

    confirmDialog.afterClosed().subscribe(result => {
      if (result === true) {
        this.accountAngularService.deleteAccount(username);
        window.location.reload();
      }
    });
  }

}
