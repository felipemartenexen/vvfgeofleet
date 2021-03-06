import { Injectable } from '@angular/core';
import { Observable, Subscription, Subject, of } from "rxjs";

import { ParametriGeoFleetWS } from '../shared/model/parametri-geofleet-ws.model';

@Injectable({
  providedIn: 'root'
})
export class GestioneParametriService {

  private subjectParametriGeoFleetWS$ = new Subject<ParametriGeoFleetWS>();
  private parametriGeoFleetWS : ParametriGeoFleetWS;



  constructor() { 
    this.parametriGeoFleetWS = new ParametriGeoFleetWS();
  }


  public getParametriGeoFleetWS(): Observable<ParametriGeoFleetWS> {
    //console.log('GestioneParametriService - getParametriGeoFleetWS()',this.parametriGeoFleetWS);
    return this.subjectParametriGeoFleetWS$.asObservable();
  }

  public resetParametriGeoFleetWS(): void { 
    this.parametriGeoFleetWS.reset();
    this.subjectParametriGeoFleetWS$.next(this.parametriGeoFleetWS);
  }

  public setRichiestaAPI(value : string): void { 
    this.parametriGeoFleetWS.setRichiestaAPI(value);
    this.subjectParametriGeoFleetWS$.next(this.parametriGeoFleetWS);    
  }
  
  public setAttSec(value : number): void { 
    this.parametriGeoFleetWS.setAttSec(value);

    this.subjectParametriGeoFleetWS$.next(this.parametriGeoFleetWS);    
  }

  public setRettangoloRicerca(evento) {
    if (evento != null) {
      
      var vv = Object.values(evento);
      var vv1 = Object.values(vv[0]);
      var vv2 = Object.values(vv[1]);

      this.parametriGeoFleetWS.setLat1(vv1[1]);
      this.parametriGeoFleetWS.setLon1(vv2[0]);
      this.parametriGeoFleetWS.setLat2(vv1[0]);
      this.parametriGeoFleetWS.setLon2(vv2[1]);

      this.subjectParametriGeoFleetWS$.next(this.parametriGeoFleetWS);    

      //console.log('setRettangoloRicerca',this.parametriGeoFleetWS);
    }
  }
    
}
