namespace Flights.ReadModels
{
    public record FlightRm(Guid Id, string Airline, String Price, TimePlaceRm departure, TimePlaceRm Arrival, int RemainingNumberOfSeats);

}
