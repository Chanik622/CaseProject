
export interface CaseDetail {
    caseId: number;
    caseName: string;
    openingDate: Date;
    status: CaseStatus;
    assignedTo: string;
    judgeId: number | null;
    judgeName: string | null;
    caseType: string;
}

export enum CaseStatus {
  OpendCase = 1,
  closedCase,
  FreezeCase
}