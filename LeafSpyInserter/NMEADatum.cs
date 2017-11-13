using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMEAInserter
{
    class NMEADatum
    {
        public object androidTime;
        public object numberOfAllSentences;
        public object sentenceNumber;
        public object numberOfAllSatellites;
        public object satelliteNumber;
        public object elevation;
        public object azimuth;
        public object SNRatio;
        public object checkSum;
        public object UTCTime;
        public object latitude;
        public object NorS;
        public object longitude;
        public object EorW;
        public object positionIdentificationQuality;
        public object HDOP;
        public object VDOP;
        public object PDOP;
        public object numberOfUsingSatellites;
        public object heightOfAntenna;
        public object unitOfAntenna;
        public object heightOfGeoid;
        public object unitOfGeoid;
        public object DGPSTime;
        public object DGPSStationId;
        public object mode;
        public object identificationType;
        public object UTCDate;
        public object status;
        public object movingSpeed;
        public object movingAzimuth;
        public object magneticVariation;
        public object magneticVariationDeclination;
        
        public void setAndroidTime(object androidTime)//Androidの内部時間（タイムスタンプ）
        {
            androidTime = Returnmethod(androidTime);
            this.androidTime = androidTime;
        }
        public void setNumberOfAllSentences(object numberOfAllSentences)//総センテンス数
        {
            numberOfAllSentences = Returnmethod(numberOfAllSentences);
            this.numberOfAllSentences = numberOfAllSentences;
        }
        public void setSentenceNumber(object sentenceNumber)//現在のセンテンス番号
        {
            sentenceNumber = Returnmethod(sentenceNumber);
            this.sentenceNumber = sentenceNumber;
        }
        public void setNumberOfAllSatellites(object numberOfAllSatellites)//総衛星数
        {
            numberOfAllSatellites = Returnmethod(numberOfAllSatellites);
            this.numberOfAllSatellites = numberOfAllSatellites;
        }
        public void setSatelliteNumber(object satelliteNumber)//衛星番号
        {
            satelliteNumber = Returnmethod(satelliteNumber);
            this.satelliteNumber = satelliteNumber;
        }
        public void setElevation(object elevation)//衛星仰角
        {
            elevation = Returnmethod(elevation);
            this.elevation = elevation;
        }
        public void setAzimuth(object azimuth)//衛星方位角
        {
            azimuth = Returnmethod(azimuth);
            this.azimuth = azimuth;
        }
        public void setSNRatio(object SNRatio)//SN（キャリア/ノイズ）比
        {
            SNRatio = Returnmethod(SNRatio);
            this.SNRatio = SNRatio;
        }
        public void setCheckSum(object checkSum)//チェックサム
        {
            checkSum = Returnmethod(checkSum);
            this.checkSum = checkSum;
        }
        public void setUTCTime(object UTCTime)//UTCにおける時間
        {
            UTCTime = Returnmethod(UTCTime);
            this.UTCTime = UTCTime;
        }
        public void setUTCDate(object UTCDate)//UTCにおける日付
        {
            UTCDate = Returnmethod(UTCDate);
            this.UTCDate = UTCDate;
        }
        public void setLatitude(object latitude)//緯度
        {
            latitude = Returnmethod(latitude);
            this.latitude = latitude;
        }
        public void setNorS(object NorS)//北緯か南緯か
        {
            NorS = Returnmethod(NorS);
            this.NorS = NorS;
        }
        public void setLongitude(object longitude)//経度
        {
            longitude = Returnmethod(longitude);
            this.longitude = longitude;
        }
        public void setEorW(object EorW)//東経か西経か
        {
            EorW = Returnmethod(EorW);
            this.EorW = EorW;
        }
        public void setPositionIdentificationQuality(object positionIdentificationQuality)//位置特定品質
        {
            positionIdentificationQuality = Returnmethod(positionIdentificationQuality);
            this.positionIdentificationQuality = positionIdentificationQuality;
        }
        public void setHDOP(object HDOP)//水平精度劣化係数
        {
            HDOP = Returnmethod(HDOP);
            this.HDOP = HDOP;
        }
        public void setVDOP(object VDOP)//垂直精度劣化係数
        {
            VDOP = Returnmethod(VDOP);
            this.VDOP = VDOP;
        }
        public void setPDOP(object PDOP)//位置精度劣化係数
        {
            PDOP = Returnmethod(PDOP);
            this.PDOP = PDOP;
        }
        public void setNumberOfUsingSatellites(object numberOfUsingSatellites)//使用衛星数
        {
            numberOfUsingSatellites = Returnmethod(numberOfUsingSatellites);
            this.numberOfUsingSatellites = numberOfUsingSatellites;
        }
        public void setHeightOfAntenna(object heightOfAntenna)//アンテナ海抜高
        {
            heightOfAntenna = Returnmethod(heightOfAntenna);
            this.heightOfAntenna = heightOfAntenna;
        }
        public void setUnitOfAntenna(object unitOfAntenna)//アンテナ海抜高の単位
        {
            unitOfAntenna = Returnmethod(unitOfAntenna);
            this.unitOfAntenna = unitOfAntenna;
        }
        public void setHeightOfGeoid(object heightOfGeoid)//ジオイド高
        {
            heightOfGeoid = Returnmethod(heightOfGeoid);
            this.heightOfGeoid = heightOfGeoid;
        }
        public void setUnitOfGeoid(object unitOfGeoid)//ジオイド高の単位
        {
            unitOfGeoid = Returnmethod(unitOfGeoid);
            this.unitOfGeoid = unitOfGeoid;
        }
        public void setDGPSTime(object DGPSTime)//最終のDGPSデータの残存時間
        {
            DGPSTime = Returnmethod(DGPSTime);
            this.DGPSTime = DGPSTime;
        }
        public void setDGPSStationId(object DGPSStationId)//DGPS基地局のID
        {
            DGPSStationId = Returnmethod(DGPSStationId);
            this.DGPSStationId = DGPSStationId;
        }
        public void setMode(object mode)//モード
        {
            mode = Returnmethod(mode);
            this.mode = mode;
        }
        public void setIdentificationType(object identificationType)//特定タイプ
        {
            identificationType = Returnmethod(identificationType);
            this.identificationType = identificationType;
        }
        public void setStatus(object status)//ステータス
        {
            status = Returnmethod(status);
            this.status = status;
        }
        public void setMovingSpeed(object movingSpeed)//地表での移動スピード
        {
            movingSpeed = Returnmethod(movingSpeed);
            this.movingSpeed = movingSpeed;
        }
        public void setMovingAzimuth(object movingAzimuth)//移動の方角
        {
            movingAzimuth = Returnmethod(movingAzimuth);
            this.movingAzimuth = movingAzimuth;
        }
        public void setMagneticVariation(object magneticVariation)//磁気変動
        {
            magneticVariation = Returnmethod(magneticVariation);
            this.magneticVariation = magneticVariation;
        }
        public void setMagneticVariationDeclination(object magneticVariationDeclination)//磁気変動偏角
        {
            magneticVariationDeclination = Returnmethod(magneticVariationDeclination);
            this.magneticVariationDeclination = magneticVariationDeclination;
        }

        public void setDatumByIndex(int index, Object datum, String DataType)
        {
            switch (DataType) {
                case "$QZGSV":
                    {
                        switch (index)
                        {
                            case 0:
                                setAndroidTime(datum);
                                break;
                            case 1:
                                break;
                            case 2:
                                setNumberOfAllSentences(datum);
                                break;
                            case 3:
                                setSentenceNumber(datum);
                                break;
                            case 4:
                                setNumberOfAllSatellites(datum);
                                break;
                            case 5:
                                setSatelliteNumber(datum);
                                break;
                            case 6:
                                setElevation(datum);
                                break;
                            case 7:
                                setAzimuth(datum);
                                break;
                        }
                    }
                    break;

                case "$QZGSV-2":
                    {
                        switch (index)
                        {
                            case 0:
                                setAndroidTime(datum);
                                break;
                            case 1:
                                break;
                            case 2:
                                setNumberOfAllSentences(datum);
                                break;
                            case 3:
                                setSentenceNumber(datum);
                                break;
                            case 4:
                                setNumberOfAllSatellites(datum);
                                break;
                            case 5:
                                setSatelliteNumber(datum);
                                break;
                            case 6:
                                setElevation(datum);
                                break;
                            case 7:
                                setAzimuth(datum);
                                break;
                            case 8:
                                setSNRatio(datum);
                                break;
                            case 9:
                                setSatelliteNumber(datum);
                                break;
                            case 10:
                                setElevation(datum);
                                break;
                            case 11:
                                setAzimuth(datum);
                                break;
                        }
                    }
                    break;
                    

                case "$GPGGA":
                    {
                        switch (index)
                        {
                            case 0:
                                setAndroidTime(datum);
                                break;
                            case 1:
                                break;
                            case 2:
                                setUTCTime(datum);
                                break;
                            case 3:
                                setLatitude(datum);
                                break;
                            case 4:
                                setNorS(datum);
                                break;
                            case 5:
                                setLongitude(datum);
                                break;
                            case 6:
                                setEorW(datum);
                                break;
                            case 7:
                                setPositionIdentificationQuality(datum);
                                break;
                            case 8:
                                setNumberOfUsingSatellites(datum);
                                break;
                            case 9:
                                setHDOP(datum);
                                break;
                            case 10:
                                setHeightOfAntenna(datum);
                                break;
                            case 11:
                                setUnitOfAntenna(datum);
                                break;
                            case 12:
                                setHeightOfGeoid(datum);
                                break;
                            case 13:
                                setUnitOfGeoid(datum);
                                break;
                            case 14:
                                setDGPSTime(datum);
                                break;
                            case 15:
                                setCheckSum(datum);
                                break;
                        }
                    }
                    break;

                case "$GPRMC":
                    {
                        switch (index)
                        {
                            case 0:
                                setAndroidTime(datum);
                                break;
                            case 1:
                                break;
                            case 2:
                                setUTCTime(datum);
                                break;
                            case 3:
                                setStatus(datum);
                                break;
                            case 4:
                                setLatitude(datum);
                                break;
                            case 5:
                                setNorS(datum);
                                break;
                            case 6:
                                setLongitude(datum);
                                break;
                            case 7:
                                setEorW(datum);
                                break;
                            case 8:
                                setMovingSpeed(datum);
                                break;
                            case 9:
                                setMovingAzimuth(datum);
                                break;
                            case 10:
                                setUTCDate(datum);
                                break;
                            case 11:
                                setMagneticVariation(datum);
                                break;
                            case 12:
                                setMagneticVariationDeclination(datum);
                                break;
                        }
                    }
                    break;

                case "$GNGSA":
                    {
                        switch (index)
                        {
                            case 0:
                                setAndroidTime(datum);
                                break;
                            case 1:
                                break;
                            case 2:
                                setMode(datum);
                                break;
                            case 3:
                                setIdentificationType(datum);
                                break;
                            case 4:
                                setSatelliteNumber(datum);
                                break;
                            case 5:
                                setSatelliteNumber(datum);
                                break;
                            case 6:
                                setSatelliteNumber(datum);
                                break;
                            case 7:
                                setSatelliteNumber(datum);
                                break;
                            case 8:
                                setSatelliteNumber(datum);
                                break;
                            case 9:
                                setSatelliteNumber(datum);
                                break;
                            case 10:
                                setSatelliteNumber(datum);
                                break;
                            case 11:
                                setSatelliteNumber(datum);
                                break;
                            case 12:
                                setSatelliteNumber(datum);
                                break;
                            case 13:
                                setSatelliteNumber(datum);
                                break;
                            case 14:
                                setSatelliteNumber(datum);
                                break;
                            case 15:
                                setSatelliteNumber(datum);
                                break;
                            case 16:
                                setPDOP(datum);
                                break;
                            case 17:
                                setHDOP(datum);
                                break;
                        }
                    }                
                    break;

                case "$GPGSA":
                    {
                        switch (index)
                        {
                            case 0:
                                setAndroidTime(datum);
                                break;
                            case 1:
                                break;
                            case 2:
                                setMode(datum);
                                break;
                            case 3:
                                setIdentificationType(datum);
                                break;
                            case 4:
                                setSatelliteNumber(datum);
                                break;
                            case 5:
                                setSatelliteNumber(datum);
                                break;
                            case 6:
                                setSatelliteNumber(datum);
                                break;
                            case 7:
                                setSatelliteNumber(datum);
                                break;
                            case 8:
                                setSatelliteNumber(datum);
                                break;
                            case 9:
                                setSatelliteNumber(datum);
                                break;
                            case 10:
                                setSatelliteNumber(datum);
                                break;
                            case 11:
                                setSatelliteNumber(datum);
                                break;
                            case 12:
                                setSatelliteNumber(datum);
                                break;
                            case 13:
                                setSatelliteNumber(datum);
                                break;
                            case 14:
                                setSatelliteNumber(datum);
                                break;
                            case 15:
                                setSatelliteNumber(datum);
                                break;
                            case 16:
                                setPDOP(datum);
                                break;
                            case 17:
                                setHDOP(datum);
                                break;
                        }
                    }
                    break;

                case "$QZGSA":
                    {
                        switch (index)
                        {
                            case 0:
                                setAndroidTime(datum);
                                break;
                            case 1:
                                break;
                            case 2:
                                setMode(datum);
                                break;
                            case 3:
                                setIdentificationType(datum);
                                break;
                            case 4:
                                setSatelliteNumber(datum);
                                break;
                            case 5:
                                setSatelliteNumber(datum);
                                break;
                            case 6:
                                setSatelliteNumber(datum);
                                break;
                            case 7:
                                setSatelliteNumber(datum);
                                break;
                            case 8:
                                setSatelliteNumber(datum);
                                break;
                            case 9:
                                setSatelliteNumber(datum);
                                break;
                            case 10:
                                setSatelliteNumber(datum);
                                break;
                            case 11:
                                setSatelliteNumber(datum);
                                break;
                            case 12:
                                setSatelliteNumber(datum);
                                break;
                            case 13:
                                setSatelliteNumber(datum);
                                break;
                            case 14:
                                setSatelliteNumber(datum);
                                break;
                            case 15:
                                setSatelliteNumber(datum);
                                break;
                            case 16:
                                setPDOP(datum);
                                break;
                            case 17:
                                setHDOP(datum);
                                break;
                        }
                    }
                    break;

                case "$GPGSV-1":
                    {
                        switch (index)
                        {
                            case 0:
                                setAndroidTime(datum);
                                break;
                            case 1:
                                break;
                            case 2:
                                setNumberOfAllSentences(datum);
                                break;
                            case 3:
                                setSentenceNumber(datum);
                                break;
                            case 4:
                                setNumberOfAllSatellites(datum);
                                break;
                            case 5:
                                setSatelliteNumber(datum);
                                break;
                            case 6:
                                setElevation(datum);
                                break;
                            case 7:
                                setAzimuth(datum);
                                break;

                        }
                    }
                    break;

                case "$GPGSV-2":
                    {
                        switch (index)
                        {
                            case 0:
                                setAndroidTime(datum);
                                break;
                            case 1:
                                break;
                            case 2:
                                setNumberOfAllSentences(datum);
                                break;
                            case 3:
                                setSentenceNumber(datum);
                                break;
                            case 4:
                                setNumberOfAllSatellites(datum);
                                break;
                            case 5:
                                setSatelliteNumber(datum);
                                break;
                            case 6:
                                setElevation(datum);
                                break;
                            case 7:
                                setAzimuth(datum);
                                break;
                            case 8:
                                setSNRatio(datum);
                                break;
                            case 9:
                                setSatelliteNumber(datum);
                                break;
                            case 10:
                                setElevation(datum);
                                break;
                            case 11:
                                setAzimuth(datum);
                                break;
                        }
                    }
                    break;

                case "$GPGSV-3":
                    {
                        switch (index)
                        {
                            case 0:
                                setAndroidTime(datum);
                                break;
                            case 1:
                                break;
                            case 2:
                                setNumberOfAllSentences(datum);
                                break;
                            case 3:
                                setSentenceNumber(datum);
                                break;
                            case 4:
                                setNumberOfAllSatellites(datum);
                                break;
                            case 5:
                                setSatelliteNumber(datum);
                                break;
                            case 6:
                                setElevation(datum);
                                break;
                            case 7:
                                setAzimuth(datum);
                                break;
                            case 8:
                                setSNRatio(datum);
                                break;
                            case 9:
                                setSatelliteNumber(datum);
                                break;
                            case 10:
                                setElevation(datum);
                                break;
                            case 11:
                                setAzimuth(datum);
                                break;
                            case 12:
                                setSNRatio(datum);
                                break;
                            case 13:
                                setSatelliteNumber(datum);
                                break;
                            case 14:
                                setElevation(datum);
                                break;
                            case 15:
                                setAzimuth(datum);
                                break;
                        }
                    }
                    break;

                case "$GPGSV-4":
                    {
                        switch (index)
                        {
                            case 0:
                                setAndroidTime(datum);
                                break;
                            case 1:
                                break;
                            case 2:
                                setNumberOfAllSentences(datum);
                                break;
                            case 3:
                                setSentenceNumber(datum);
                                break;
                            case 4:
                                setNumberOfAllSatellites(datum);
                                break;
                            case 5:
                                setSatelliteNumber(datum);
                                break;
                            case 6:
                                setElevation(datum);
                                break;
                            case 7:
                                setAzimuth(datum);
                                break;
                            case 8:
                                setSNRatio(datum);
                                break;
                            case 9:
                                setSatelliteNumber(datum);
                                break;
                            case 10:
                                setElevation(datum);
                                break;
                            case 11:
                                setAzimuth(datum);
                                break;
                            case 12:
                                setSNRatio(datum);
                                break;
                            case 13:
                                setSatelliteNumber(datum);
                                break;
                            case 14:
                                setElevation(datum);
                                break;
                            case 15:
                                setAzimuth(datum);
                                break;
                            case 16:
                                setSNRatio(datum);
                                break;
                            case 17:
                                setSatelliteNumber(datum);
                                break;
                            case 18:
                                setElevation(datum);
                                break;
                            case 19:
                                setAzimuth(datum);
                                break;
                        }
                    }
                    break;
                    
            }
          
        }
        private Object Returnmethod(Object obj)
        {
            Object nullobj;
            if (Convert.ToString(obj) == "null")
            {
                nullobj = Convert.ToString(obj);
                return nullobj;
            }
            else return obj;
        }
    }
 
}


