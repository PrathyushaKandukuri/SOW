import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { DashboardComponent } from './dashboard.component';
import { DashboardService } from '../shared/Services/DashbordService/dashboard.service';
import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { of } from 'rxjs';
import { NgChartsModule } from 'ng2-charts';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonService } from '../common.service';

describe('DashboardComponent', () => {
  let component: DashboardComponent;
  let fixture: ComponentFixture<DashboardComponent>;
  let mockDashboardService: any, mockrouter: any, mockroute: any, mockcommonservice: any;

  beforeEach(waitForAsync(() => {
    mockDashboardService = jasmine.createSpyObj('DashboardService', ['GetSODashboardData']);
    mockcommonservice = jasmine.createSpyObj('CommonService', ['GetIsFromLogin']);
    TestBed.configureTestingModule({
      declarations: [DashboardComponent],
      providers: [
        { provide: DashboardService, useValue: mockDashboardService },
        { provide: Router, useValue: mockrouter },
        { provide: ActivatedRoute, useValue: mockroute },
        { provide: CommonService, useValue: mockcommonservice },
      ],
      imports: [NgChartsModule],
      schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA],
    }).compileComponents();

    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should handle getSODashboardData and chart creation', () => {
    component.period = 'Monthly';
    spyOn(component, 'getSODashboardData').and.callThrough();
    spyOn(component, 'statusChart');
    spyOn(component, 'domainChart');
    spyOn(component, 'regionChart');

    // Mock the service response
    const mockSODashboardData = [
      { category: 'Status', name: 'Cancelled', count: 0 },
      { category: 'Domain', name: 'Analytics', count: 0 },
      { category: 'Region', name: 'US', count: 0 },
    ];
    mockDashboardService.GetSODashboardData.and.returnValue(of(mockSODashboardData));

    // Call the method
    component.getSODashboardData();

    // Assert that the methods are called
    expect(component.getSODashboardData).toHaveBeenCalled();
    expect(component.statusChart).toHaveBeenCalled();
    expect(component.domainChart).toHaveBeenCalled();
    expect(component.regionChart).toHaveBeenCalled();
  });
  it('selectionChange',()=>{
    component.period = 'Monthly';
    spyOn(component, 'getSODashboardData').and.callThrough();
    spyOn(component, 'statusChart');
    spyOn(component, 'domainChart');
    spyOn(component, 'regionChart');

    // Mock the service response
    const mockSODashboardData = [
      { category: 'Status', name: 'Cancelled', count: 0 },
      { category: 'Domain', name: 'Analytics', count: 0 },
      { category: 'Region', name: 'US', count: 0 },
    ];
    mockDashboardService.GetSODashboardData.and.returnValue(of(mockSODashboardData));

    // Call the method
    component.selectionChange(component.period);

    // Assert that the methods are called
    expect(component.getSODashboardData).toHaveBeenCalled();
    expect(component.statusChart).toHaveBeenCalled();
    expect(component.domainChart).toHaveBeenCalled();
    expect(component.regionChart).toHaveBeenCalled();
  })
  it('ngAfterViewInit',()=>{
    spyOn(component, 'domainChart');
    component.ngAfterViewInit()
  })
  it('ngOnInit',()=>{
    component.period = 'Monthly';
    spyOn(component, 'getSODashboardData').and.callThrough();
    spyOn(component, 'statusChart');
    spyOn(component, 'domainChart');
    spyOn(component, 'regionChart');

    // Mock the service response
    const mockSODashboardData = [
      { category: 'Status', name: 'Cancelled', count: 0 },
      { category: 'Domain', name: 'Analytics', count: 0 },
      { category: 'Region', name: 'US', count: 0 },
    ];
    mockDashboardService.GetSODashboardData.and.returnValue(of(mockSODashboardData));

    // Call the method
    component.ngOnInit();

    // Assert that the methods are called
    expect(component.getSODashboardData).toHaveBeenCalled();
    expect(component.statusChart).toHaveBeenCalled();
    expect(component.domainChart).toHaveBeenCalled();
    expect(component.regionChart).toHaveBeenCalled();
  })
});
