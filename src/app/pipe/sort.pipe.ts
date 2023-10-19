import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sort'
})
export class SortPipe implements PipeTransform {

  transform(value: Array<string>, args:any[]): any {
    const sortField=args[0];
    const sortDirection=args[1];
    if(sortDirection=='Desc')
    value.sort((a:any,b:any)=>{
      if(a[sortField]<b[sortField])
      return 1;
      if(a[sortField]>b[sortField])
      return -1;
      return 0;
    });

    else if(sortDirection=='Asc')
    value.sort((a:any,b:any)=>{
      if(a[sortField]<b[sortField])
      return -1;
      if(a[sortField]>b[sortField])
      return 1;
      return 0;
    });


    return value;
  }

} 
