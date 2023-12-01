import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value: any[], filter:Array<any>): any[] {
    const resultArray=[];
    if(filter.length===0)
    return value;
  console.log(filter);
  for(const item of value){

    if(filter.includes(item['location']))
    {
      resultArray.push(item);
    }
  }
  console.log(resultArray);
  return resultArray;
  }

}
