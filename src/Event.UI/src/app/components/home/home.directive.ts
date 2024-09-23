import { Directive, ElementRef, HostListener } from "@angular/core";

@Directive({
    selector:'[homeDirective]'
})

export class HomeDirective {
    constructor(private el : ElementRef) {}


    @HostListener('mouseenter') onMouseEnter(){
        this.highlight("lightblue");
    }


    private highlight(color: string){
        var element =  this.el.nativeElement.getElementsByTagName('tr').InnerHtml;
        console.log(element);
    }
}