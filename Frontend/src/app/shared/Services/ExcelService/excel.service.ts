import { Injectable } from '@angular/core';
import * as FileSaver from 'file-saver';


import 'jspdf-autotable';
import { saveAs } from 'file-saver';
import * as XLSX from 'xlsx';
import { WorkBook, WorkSheet } from 'xlsx/types';
import jsPDF from 'jspdf';


const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';

@Injectable()
export class ExcelService {
  constructor() { }

  public exportAsExcelFile(json: any[], excelFileName: string): void {
    const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(json);
    const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
    const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
    this.saveAsExcelFile(excelBuffer, excelFileName);
  }


  public jsonExportAsExcel(json: any[], excelFileName: string, headers: string[]): void {
    const worksheet: WorkSheet = XLSX.utils.json_to_sheet(json, { header: headers });
    worksheet['!cols'] = [];

    const wb: WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, worksheet, 'Sheet1');
    //XLSX.utils.book_append_sheet(wb, worksheet, 'Sheet2');

    const excelBuffer: any = XLSX.write(wb, { bookType: 'xlsx', type: 'array' });
    this.saveAsExcelFile(excelBuffer, excelFileName);
  }


  public jsonExportAsExcelExperiment(json: any[], excelFileName: string, headers: string[], statuses: string[]): void {
    const wb: XLSX.WorkBook = XLSX.utils.book_new();

    // Create worksheet for Sheet1
    const worksheetSheet1: XLSX.WorkSheet = XLSX.utils.json_to_sheet(json);
    worksheetSheet1['!cols'] = [];

    // Add filter options to each column header
    const endCellRefSheet1 = XLSX.utils.encode_cell({ r: json.length, c: headers.length - 1 });
    worksheetSheet1['!autofilter'] = { ref: `A1:${endCellRefSheet1}` };

    // Manually insert headers at the beginning of the sheet
    XLSX.utils.sheet_add_json(worksheetSheet1, [{}], { header: headers, skipHeader: true, origin: 'A1' });

    XLSX.utils.book_append_sheet(wb, worksheetSheet1, 'Sheet1');

    // Create worksheet for Sheet2
    const dataForSheet2: any[][] = statuses.map(status => [status]);
    const worksheetSheet2: XLSX.WorkSheet = XLSX.utils.aoa_to_sheet(dataForSheet2);
    worksheetSheet2['!cols'] = [];
    XLSX.utils.book_append_sheet(wb, worksheetSheet2, 'Sheet2');

    const excelBuffer: any = XLSX.write(wb, { bookType: 'xlsx', type: 'array' });
    this.saveAsExcelFile(excelBuffer, excelFileName);
}


  private isObject(values: any): boolean {
    return !Array.isArray(values);
  }

  private getKeys(object: any[] | null): string[] {
    if (object != null) {
      const headers = Object.keys(object).map((x) => x.toUpperCase());
      return headers;
    } else {
      return [];
    }
  }

  private isValue(value: any): boolean {
    return typeof value !== 'object';
  }

  private saveAsExcelFile(buffer: any, fileName: string): void {
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE,
    });
    FileSaver.saveAs(data, fileName + '_' + new Date().getTime() + EXCEL_EXTENSION);
  }
  public exportEmptyExcelFile(excelFileName: string, headers: string[]): void {
    const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet([{}], { header: headers });
    worksheet['!cols'] = headers.map((_, index) => ({ wch: 15 })); // Adjust the column widths as needed

    const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
    const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });

    this.saveAsExcelFile(excelBuffer, excelFileName);
  }



  private saveAsPdfFile(pdf: any, fileName: string): void {
    pdf.save(`${fileName}_${new Date().getTime()}.pdf`);
  }
  
  public exportEmptyPdfFile(pdfFileName: string, headers: string[]): void {
    const pdf = new jsPDF();
    const autoTable = (jsPDF as any).autoTable; // Use the "as any" to bypass TypeScript error
  
    // Add content to the PDF document, adjust as needed
    pdf.text('Hello, this is an empty PDF file.', 10, 10);
  
    // AutoTable configuration
    const autoTableConfig = {
      head: [headers],
      body: [[]], // Empty data row
      theme: 'grid',
      styles: {
        halign: 'center',
      },
    };
  
    // Add AutoTable to the PDF document
    autoTable(pdf, autoTableConfig);
  
    this.saveAsPdfFile(pdf, pdfFileName);
  }


  public exportToExcel(data: any[], headers: string[]): void {
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(data);
  
    // Add filter options to each column header
    const endCellRef = XLSX.utils.encode_cell({ r: data.length, c: headers.length - 1 });
    worksheet['!autofilter'] = { ref: `A1:${endCellRef}` };
  
    // Manually insert headers at the beginning of the sheet
    XLSX.utils.sheet_add_json(worksheet, [{}], { header: headers, skipHeader: true, origin: 'A1' });
  
    XLSX.utils.book_append_sheet(wb, worksheet, 'Sheet1');
  
    const excelBuffer: any = XLSX.write(wb, { bookType: 'xlsx', type: 'array' });
    this.saveAsFile(excelBuffer, 'Candidate_Details', 'xlsx');
  }
  
  public exportToPDF(data: any[], headers: string[]): void {
    // Your PDF export logic here...
    // You can use a library like jsPDF or html2pdf to generate PDF from HTML or data.
    // Example: https://github.com/eKoopmans/html2pdf
  
    // Make sure to handle PDF export logic based on your requirements.
  }
  
  public saveAsFile(buffer: any, fileName: string, fileExtension: string): void {
    const data: Blob = new Blob([buffer], { type: EXCEL_TYPE });
    FileSaver.saveAs(data, `${fileName}_${new Date().getTime()}.${fileExtension}`);
  }


}
