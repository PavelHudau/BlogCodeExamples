import src.user as usr
import src.user_repository as u_repo


def test_user_authentication():
    # GIVEN
    user = usr.User()
    repo = u_repo.UserRepository()
    repo.add_user(user)
    try:
        # WHEN:
        user.authenticate()
        # THEN
        assert user.is_authenticated
    finally:
        # CLEANUP
        repo.delete_user(user)
