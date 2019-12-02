

    function CalculateFuel (weight: number)
    {
        let answer = (Math.floor(weight / 3) - 2)

        if (answer > 0)
        {
            return answer + this.CalculateFuel(answer);
        }
        return 0; 
    }


    export { CalculateFuel };

