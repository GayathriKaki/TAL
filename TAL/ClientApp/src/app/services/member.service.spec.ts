import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController} from '@angular/common/http/testing';
import { MemberService } from './member.service';
import { DataService } from './data.service';
import { InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpHandler } from "@angular/common/http";
export const BASE_URL = new InjectionToken<string>('BASE_URL');

export function getBaseUrl() {
  return 'http://localhost';
}


describe('MemberService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
    ],
      providers: [MemberService,  DataService, HttpClient,
        { provide: 'BASE_URL', useFactory: getBaseUrl, deps: []  }, HttpClient, HttpHandler
      ]
    });
  });

  it('premium service should be created', inject([MemberService], (service: MemberService) => {
    expect(service).toBeTruthy();
  }));
});
