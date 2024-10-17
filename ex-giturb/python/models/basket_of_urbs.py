from pydantic import BaseModel
from typing import List
from models.urb import Urb


class BasketOfUrbs(BaseModel):
    id: int
    urbs: List[Urb] = []

    def is_ready_to_send(self):
        # more than 0, less than 10 but not 7. Should throw exceptions if they do not meet the criteria
        if len(self.urbs) == 0:
            return False
        elif len(self.urbs) == 7:
            raise Exception("Basket cannot have 7 Urbs")
        elif len(self.urbs) >= 10:
            raise Exception("Basket cannot have more than 10 urbs")
        else:
            return True
