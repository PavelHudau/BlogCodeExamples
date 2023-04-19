import pytest
import src.user as usr
import src.user_repository as u_repo


@pytest.fixture
def tmp_user():
    user = usr.User()
    # Add user to the database before test runs.
    repo = u_repo.UserRepository()
    repo.add_user(user)
    yield user
    # Delete user from the database after test completes,
    # either fails or passes.
    repo.delete_user(user)


def test_user_authentication(tmp_user: usr.User):
    tmp_user.authenticate()
    assert tmp_user.is_authenticated
