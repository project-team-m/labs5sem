from django.urls import path

from . import views

app_name = 'admin_user'
urlpatterns = [
    path('/components/', views.show_components, name='admin_user'),
]
