from django.urls import path

from . import views

app_name = 'admin_user1'
urlpatterns = [
    path('/components/', views.show_components, name='components'),
]
