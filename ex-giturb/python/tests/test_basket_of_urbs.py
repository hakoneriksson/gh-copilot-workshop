import pytest
from models.urb import Urb
from models.basket_of_urbs import BasketOfUrbs

@pytest.fixture
def urb():
    return Urb(id=1, name="Cilantro")

def test_empty_basket_not_ready(urb):
    basket = BasketOfUrbs(id=1, urbs=[])
    assert not basket.is_ready_to_send()