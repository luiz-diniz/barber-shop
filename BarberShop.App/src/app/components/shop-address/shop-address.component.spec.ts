import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopAddressComponent } from './shop-address.component';

describe('ShopAddressComponent', () => {
  let component: ShopAddressComponent;
  let fixture: ComponentFixture<ShopAddressComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShopAddressComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShopAddressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
