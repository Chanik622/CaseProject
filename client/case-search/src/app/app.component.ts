import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CasesComponent } from './cases/cases.component';
import { HttpClientModule } from '@angular/common/http';
import { CaseDetailsComponent } from './cases/case-details/case-details.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CasesComponent,HttpClientModule,CaseDetailsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'case-search';
}
