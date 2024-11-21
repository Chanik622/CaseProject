import { Pipe, PipeTransform } from '@angular/core';
import { CaseStatus } from './models/case';

@Pipe({
  name: 'caseStatusPipe',
  standalone: true
})
export class CaseStatusPipe implements PipeTransform {
  transform(value: CaseStatus): string {
    switch (value) {
      case CaseStatus.OpendCase:
        return 'תיק פתוח';
      case CaseStatus.closedCase:
        return 'תיק סגור';
      case CaseStatus.FreezeCase:
        return 'תיק מוקפא';
      default:
        return 'לא ידוע';
    }
  }
}