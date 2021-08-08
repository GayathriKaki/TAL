import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MemberService } from '../services/member.service';
import {  IOccupation, IMember,IStates } from '../model/premium';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html'
})
export class CalculatorComponent implements OnInit  {
  @ViewChild(NgForm) premiumForm: NgForm;

  //premium: IPremium = {
  //  name: '',
  //  age: 0,
  //  dateOfBirth: new Date(),
  //  deathSumInsured: 0,
  //  occupationId: 0,
  //  premium: 0,
  //};
  isNextButton: boolean;
  isBackButton: boolean;
  isSubmitButton: boolean;
  errorReceived: boolean;
  ismemberScreen2: boolean;
  ismemberScreen1: boolean;
  public statesList: IStates[];
  public occupations: IOccupation[];
  occupationList: IOccupation[];
  public membermodel: IMember = {
    name: '',
    age: undefined,
    dateOfBirth: new Date(),
    deathSumInsured: undefined,   
    occupationId: undefined,
    premium: 0,
    stateId: undefined,
    monthlyexpenses:0
  };

  constructor(private service: MemberService) {

  }
  ngOnInit() {
    this.getOccupationList();
    this.isBackButton = false;
    this.isNextButton = true;
    this.isSubmitButton = false;
    this.getStateList();
    this.ismemberScreen1 = true;
    this.ismemberScreen2 = false;
  }
 
  getOccupationList() {
    this.errorReceived = false;
    this.service.getOccupationList()       
      .subscribe(occlist => {
        this.occupations = occlist;         
        console.log('occupations: ' + this.occupations);
    });
  }
  getStateList() {
    this.errorReceived = false;
    this.service.getStatesList()     
      .subscribe(statelist => {
        this.statesList = statelist;       
      });
  }



  calculatePremium() {
    console.log('membermode:' + 'age=' + this.membermodel.age + ',dob=' + this.membermodel.dateOfBirth + ',sum=' + this.membermodel.deathSumInsured + ',exp=' + this.membermodel.monthlyexpenses + ',name=' + this.membermodel.name + ',occu=' + this.membermodel.occupationId + ',premium=' + this.membermodel.premium + ',stateid=' + this.membermodel.stateId)
    this.errorReceived = false;
    this.service.calculate(this.membermodel.deathSumInsured, this.membermodel.occupationId, this.membermodel.age)
      .subscribe(premium => {
       // this.premium.premium = premium;
        this.membermodel.premium = premium;
      });
  }

  backClick() {
    this.isBackButton = false;
    this.isNextButton = true;
    this.isSubmitButton = false;
    this.ismemberScreen1 = true;
    this.ismemberScreen2 = false;
  }
  nextClick() {
   
    this.isBackButton = true;
    this.isNextButton = false;
    this.ismemberScreen1 = false;
    this.ismemberScreen2 = true;
    this.isSubmitButton = true;
   
  }
  submit() {
    console.log("öValue :" + this.membermodel.occupationId);
   
   
    if (!this.premiumForm.valid) {
    return;
   }
   
    this.calculatePremium();
  }
    
}

