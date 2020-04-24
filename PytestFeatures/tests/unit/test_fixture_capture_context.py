import pytest

MODULE_VARIABLE = "MODULE_VARIABLE value"


@pytest.fixture
def awesome_fixture(request):
    print("function_fixture setup, running from")
    print(f"Module: '{request.module.__name__}''")
    print(f"Function: '{request.function.__name__}''")
    print(f"Module variable: {request.module.MODULE_VARIABLE}")

    print("SETUP")
    yield
    print("\nTEARDOWN")


def test_fixture_context(awesome_fixture):
    print(f"RUNNING : {__name__}")
    assert True
