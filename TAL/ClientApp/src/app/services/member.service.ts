import { Injectable, Inject } from '@angular/core';
import { Response } from '@angular/http';

import { DataService } from './data.service';
import { IMember, IOccupation,  IStates } from '../model/premium';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class MemberService {
  private occupationUrl = '';
  private calculationUrl = '';
  
  constructor(private service: DataService, @Inject('BASE_URL') baseUrl: string) {
   this.occupationUrl = baseUrl + 'api/occupation';
    this.calculationUrl = baseUrl + 'api/calculation';
  }

  getOccupationList(): Observable<IOccupation[]> {
        let url = this.occupationUrl + '/occupations';
    return this.service.get(url).pipe(map((response: IOccupation) => {
     
      return response;
        })
      );
  }

  getStatesList(): Observable<IStates[]> {
    let url = this.occupationUrl + '/states';
    return this.service.get(url).pipe(map((response: Response) => {
   
      return response;
    })
    );
  }

 
  calculate(DeathSumInsured, orgId, age): Observable<Number> {
    console.log("premium=" + DeathSumInsured, orgId, age);
    let url = this.calculationUrl + '/GetTotal?DeathSumInsured=' + DeathSumInsured + "&orgId=" + orgId + "&age=" + age;
    return this.service.get(url).pipe(map((response: Response) => {
      console.log("total=" + response);
      return response;
    }));
  }
}

