import { Component, Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'capitalizeFirstLetter'
})
export class CapitalizeFirstLetterPipe implements PipeTransform {
  transform(value: string): string {
    if (!value) return value;
    return value.replace(/\b\w/g, (char) => char.toUpperCase());
  }
}
@Component({
  selector: 'app-server-down',
  templateUrl: './server-down.component.html',
  styleUrls: ['./server-down.component.css']
})
export class ServerDownComponent {

}
