import { CalculateFuel } from './src/day01/rocket'

class Rocket  {
   
    total: number;

    constructor()
    {
        this.total = 0;
    }

    Calculate() {

       var moduleWeights = this.splitLines(this.GetData())
       moduleWeights.forEach(this.CalcFuel, this);
       return this.total;
    }

    CalcFuel(weight: number) {
      this.total += CalculateFuel(weight)
    }

    splitLines(t) { 
        return t.split(/\r\n|\r|\n/); 
    }

    GetData() {

    var data: string = `108404
    142663
    113953
    89187
    134971
    93901
    79832
    142582
    145387
    104530
    87533
    75312
    139459
    141201
    68801
    61163
    96040
    110287
    97738
    138959
    122690
    110331
    107930
    105938
    134097
    63599
    56781
    60741
    85313
    74432
    112114
    108556
    99115
    142180
    86957
    68882
    53394
    84383
    75073
    94942
    89506
    65782
    85816
    109814
    79113
    146432
    55951
    138827
    140796
    149851
    137353
    110513
    132480
    53724
    52292
    63473
    97705
    141506
    147125
    126996
    107361
    145397
    105546
    96261
    90682
    108029
    144607
    144603
    74959
    92000
    70920
    66026
    70196
    149729
    126996
    120026
    118383
    109199
    84628
    121412
    135413
    138807
    115286
    132455
    73051
    83131
    78528
    140029
    117782
    143779
    55642
    141798
    79406
    50167
    124606
    92822
    144622
    85043
    126924
    135624`;
    
     return data;
    
    }
}


console.log('hello world')

console.log(CalculateFuel(14))

var r = new Rocket();

document.getElementById('message').innerText =  "Result for (rocket) is: " + r.Calculate();

