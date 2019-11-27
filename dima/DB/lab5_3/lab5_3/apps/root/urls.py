from django.urls import path

from . import views

app_name = 'root'
urlpatterns = [
    path('components/', views.show_components, name='root'),
]
