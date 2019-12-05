from django.urls import path

from . import views

app_name = 'root'
urlpatterns = [
    path('', views.show_tables, name='show_tables'),
    path('components/', views.show_components, name='components'),
    path('brands/', views.show_brands, name='brands'),
    path('stocks/', views.show_stocks, name='stocks'),
    path('stock/', views.show_stock, name='stock'),
    path('clients/', views.show_clients, name='clients'),
    path('workers/', views.show_workers, name='workers'),
    path('positions/', views.show_positions, name='positions'),
    path('basket/', views.show_basket, name='basket'),
    path('orders/', views.show_orders, name='orders'),
    path('enter_components/', views.enter_components, name='enter_components'),
    path('enter_brands/', views.enter_brands, name='enter_brands'),
    path('enter_stocks/', views.enter_stocks, name='enter_stocks'),
    path('enter_stock/', views.enter_stock, name='enter_stock'),
    path('enter_workers/', views.enter_workers, name='enter_workers'),
    path('enter_positions/', views.enter_positions, name='enter_positions'),
    path('enter_orders/', views.enter_orders, name='enter_orders'),
    path('enter_basket/', views.enter_basket, name='enter_basket'),
    path('enter_clients/', views.enter_clients, name='enter_clients'),
    path('enter_components_s/', views.enter_components_s, name='enter_components_s'),
    path('enter_brands_s/', views.enter_brands_s, name='enter_brands_s'),
]
