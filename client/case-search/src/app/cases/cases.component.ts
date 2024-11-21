import { Component, OnInit } from '@angular/core';
import { CaseService } from '../services/caseService';
import { CaseDetail } from '../models/case';
import { SelectButtonModule } from 'primeng/selectbutton';
import { CardModule } from 'primeng/card';
import { filterCase } from '../models/filterCase';
import { CaseDetailsComponent } from './case-details/case-details.component';
import { FormsModule } from '@angular/forms'; 
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { DropdownModule } from 'primeng/dropdown';
import { CaseStatusPipe } from '../case-status.pipe';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-cases',
  standalone: true,
  imports: [HttpClientModule,FormsModule, SelectButtonModule,DropdownModule,CommonModule,CaseDetailsComponent,CaseStatusPipe,ButtonModule],
  templateUrl: './cases.component.html',
  styleUrls: ['./cases.component.css']
})
export class CasesComponent implements OnInit {
 
  constructor(
    private caseService: CaseService
  ) {}
  
  
  cases: CaseDetail[] = []
  selectedSort: any = null;

  searchCriteria: filterCase = {
    openingDateFrom: '',
    openingDateTo: '',
    name: '',
    filterOptions: [1] 
  };

  filterOptionsList = [
    { name: 'הכל', value: 1 },
    { name: 'תיקים שלי', value: 2 },
    { name: 'תיקים פתוחים', value: 3 },
    { name: 'תיקים סגורים', value: 4 }
  ];

  sortOptions = [
    { label: 'תאריך פתיחה', value: 'date-desc' },
    { label: 'מספר תיק', value: 'id-asc' },
  ];

  ngOnInit(): void {
    this.cases = [
      { caseId: 101, caseName: 'תיק א', openingDate: new Date('2023-11-01') , judgeId:324488030, caseType:"ערר חרבות ברזל", assignedTo:"דוד בנימיני",status:1, judgeName:"אברהם יעקב"},
      { caseId: 102, caseName: 'תיק ב', openingDate: new Date('2023-11-15') , judgeId:324488030, caseType:"ערר חרבות ברזל", assignedTo:"דוד בנימיני",status:2, judgeName:"אברהם יעקב"},
      { caseId: 103, caseName: 'תיק ג', openingDate: new Date('2023-10-30') , judgeId:324488030, caseType:"ערר חרבות ברזל", assignedTo:"דוד בנימיני",status:1, judgeName:"אברהם יעקב"},
    ];
  }
  
  onSearchFilter()
  {
    debugger;
    this.caseService.getCaseDetails(this.searchCriteria).subscribe(data => {
      this.cases = data; 
    });
  }

  onSortCases()
  {
    debugger;
    if (this.selectedSort) {
      switch (this.selectedSort?.value) {
        case 'date-desc':
          this.cases.sort((a, b) => new Date(b.openingDate).getTime() - new Date(a.openingDate).getTime());
          break;
        case 'id-asc':
          this.cases.sort((a, b) => b.caseId - a.caseId);
          break;
      }
    }
  }

}

