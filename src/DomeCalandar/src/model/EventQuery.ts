export class EventQuery{
    public pageNumber! : number;
    public pageSize!: number;

    constructor(pageNumber: number, pageSize: number){
        this.pageNumber = pageNumber;
        this.pageSize = pageSize;
    }
}