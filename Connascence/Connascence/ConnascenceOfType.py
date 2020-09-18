class ScheduleItem:
    def __init__(self):
        self.flight = ""
        self.origin = ""
        self.destination = ""
        self.departure_dt = None
        self.arrival_dt = None

    def print(self):
        return (
            f"Flight {self.flight} from {self.origin} on {self.departure_dt} "
            f"to {self.destination} on {self.arrival_dt}"
        )


class Itinerary:
    def __init__(self):
        self._schedule_items = []

    def print(self):
        printed_schedules = []
        for item in self._schedule_items:
            # No error, item is added to a collection that is supposed
            # to be a collection of strings. When code runs user will see that
            # itinerary is not printed correctly.
            printed_schedules.append(item)

            # A fix is simple, developer just forgot to call print() on an item.
            # However the error was discovered after the code was run.
            printed_schedules.append(item.print())

        return "\n".join(printed_schedules)
