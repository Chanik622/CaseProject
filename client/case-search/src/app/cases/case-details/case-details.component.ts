import { Component, CUSTOM_ELEMENTS_SCHEMA, Input } from '@angular/core';
import { SelectButtonModule } from 'primeng/selectbutton';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import {CaseStatusPipe} from '../../case-status.pipe'
import { PanelModule } from 'primeng/panel';

@Component({
  selector: 'app-case-details',
  standalone: true,
  imports: [SelectButtonModule,CommonModule, HttpClientModule, CaseStatusPipe,PanelModule],
  templateUrl: './case-details.component.html',
  styleUrl: './case-details.component.css',
})
export class CaseDetailsComponent {
  @Input() cases: any[] = []
}
