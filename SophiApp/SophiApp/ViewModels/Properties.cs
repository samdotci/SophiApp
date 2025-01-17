﻿using SophiApp.Commons;
using SophiApp.Dto;
using SophiApp.Helpers;
using SophiApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SophiApp.ViewModels
{
    internal partial class AppVM
    {
        private bool advancedSettingsVisibility;
        private List<CustomActionDto> CustomActions;
        private bool debugMode;
        private bool hamburgerHitTest;
        private bool loadingPanelVisibility;
        private LocalizationsHelper localizationsHelper;
        private ThemesHelper themesHelper;
        private bool viewsHitTest;
        private string visibleViewByTag;
        private bool windowCloseHitTest;

        public bool AdvancedSettingsVisibility
        {
            get => advancedSettingsVisibility;
            set
            {
                advancedSettingsVisibility = value;
                DebugHelper.AdvancedSettinsVisibility(value);
                OnPropertyChanged(AdvancedSettingsVisibilityPropertyName);
            }
        }

        public Theme AppSelectedTheme
        {
            get => themesHelper.SelectedTheme;
            private set
            {
                DebugHelper.SelectedTheme(value.Alias);
                OnPropertyChanged(AppSelectedThemePropertyName);
            }
        }

        public List<string> AppThemes => themesHelper.Themes.Select(theme => theme.Name).ToList();

        public int CustomActionsCounter => CustomActions.Count;

        public bool DebugMode
        {
            get => debugMode;
            set
            {
                debugMode = value;
                DebugHelper.DebugMode(value);
                OnPropertyChanged(DebugModePropertyName);
            }
        }

        public bool HamburgerHitTest
        {
            get => hamburgerHitTest;
            private set
            {
                hamburgerHitTest = value;
                OnPropertyChanged(HamburgerHitTestPropertyName);
            }
        }

        public bool LoadingPanelVisibility
        {
            get => loadingPanelVisibility;
            set
            {
                loadingPanelVisibility = value;
                OnPropertyChanged(LoadingPanelVisibilityPropertyName);
            }
        }

        public Localization Localization
        {
            get => localizationsHelper.Selected;
            private set
            {
                DebugHelper.SelectedLocalization($"{value.Language}");
                OnPropertyChanged(LocalizationPropertyName);
            }
        }

        public List<string> LocalizationList => localizationsHelper.GetNames();

        public List<TextedElement> TextedElements { get; private set; }

        public bool ViewsHitTest
        {
            get => viewsHitTest;
            private set
            {
                viewsHitTest = value;
                OnPropertyChanged(ViewsHitTestPropertyName);
            }
        }

        public string VisibleViewByTag
        {
            get => visibleViewByTag;
            private set
            {
                visibleViewByTag = value;
                DebugHelper.VisibleViewChanged(value);
                OnPropertyChanged(VisibleViewByTagPropertyName);
            }
        }

        public bool WindowCloseHitTest
        {
            get => windowCloseHitTest;
            private set
            {
                windowCloseHitTest = value;
                OnPropertyChanged(WindowCloseHitTestPropertyName);
            }
        }
    }
}