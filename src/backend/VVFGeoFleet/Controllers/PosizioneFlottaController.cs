﻿//-----------------------------------------------------------------------
// <copyright file="PosizioneFlottaController.cs" company="CNVVF">
// Copyright (C) 2017 - CNVVF
//
// This file is part of VVFGeoFleet.
// VVFGeoFleet is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
//
// SOVVF is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Web.Http;
using Modello.Classi;
using Modello.Configurazione;
using Modello.Servizi.Persistence;

namespace VVFGeoFleet.Controllers
{
    public class PosizioneFlottaController : ApiController
    {
        private readonly IGetPosizioneFlotta getPosizioneFlotta;
        private readonly IAppConfig appConfig;

        public PosizioneFlottaController(IGetPosizioneFlotta getPosizioneFlotta, IAppConfig appConfig)
        {
            this.getPosizioneFlotta = getPosizioneFlotta;
            this.appConfig = appConfig;
        }

        /// <summary>
        ///   Restituisce la posizione dell'intera flotta attiva
        /// </summary>
        /// <returns>La posizione della flotta</returns>
        [Route("api/PosizioneFlotta/")]
        public IEnumerable<MessaggioPosizione> Get()
        {
            var attSec = this.appConfig.OrizzonteTemporale_sec;

            return this.Get(null, attSec);
        }

        /// <summary>
        ///   Restituisce la posizione dell'intera flotta attiva
        /// </summary>
        /// <param name="attSec">
        ///   I secondi entro cui deve essere stato inviato l'ultimo messaggio di posizione perché il
        ///   mezzo sia considerato attivo
        /// </param>
        /// <returns>La posizione della flotta</returns>
        [Route("api/PosizioneFlotta/")]
        public IEnumerable<MessaggioPosizione> Get(int attSec)
        {
            return this.Get(null, attSec);
        }

        /// <summary>
        ///   Restituisce la posizione dell'intera flotta attiva
        /// </summary>
        /// <param name="classiMezzo">Filtro sulle classi mezzo</param>
        /// <returns>La posizione della flotta</returns>
        [Route("api/PosizioneFlotta/PerClassi")]
        public IEnumerable<MessaggioPosizione> Get([FromUri] string[] classiMezzo)
        {
            var attSec = this.appConfig.OrizzonteTemporale_sec;

            return this.Get(classiMezzo, attSec);
        }

        /// <summary>
        ///   Restituisce la posizione dell'intera flotta attiva
        /// </summary>
        /// <param name="classiMezzo">Filtro sulle classi mezzo</param>
        /// <param name="attSec">
        ///   I secondi entro cui deve essere stato inviato l'ultimo messaggio di posizione perché il
        ///   mezzo sia considerato attivo
        /// </param>
        /// <returns>La posizione della flotta</returns>
        [Route("api/PosizioneFlotta/PerClassi")]
        public IEnumerable<MessaggioPosizione> Get([FromUri] string[] classiMezzo, int attSec)
        {
            return this.getPosizioneFlotta.Get(classiMezzo, attSec);
        }
    }
}
