Feature: KoopFeature

Scenario: Check Koop Tab
	Given Open koop tab
	Then  Url path contains "/koop/"

Scenario: Check Koop Tab Elements
	Given Open koop tab
	Then  Page contains element ".autocomplete"
	And   Page contains element ".radius-filter"
	And   Page contains element ".range-filter"
	And   Page contains element ".search-block__submit"

Scenario: Search Koop Default
	Given Open koop tab
	When  Fill textbox "#autocomplete-input" as "Amsterdam"
	And   Click button ".search-block__body"
	And   Click button ".search-block__submit > button"
	Then  Url path contains "/koop/heel-nederland/"

Scenario: Search Koop Amsterdam
	Given Open koop tab
	When  Fill textbox "#autocomplete-input" as "Amsterdam"
	And   Click button ".search-block__body"
	And   Click button ".search-block__submit > button"
	Then  Url path contains "/koop/amsterdam/"

	When  Click button ".logo"
	Then  Element "" text is ""

Scenario: Quick Searcch
	Given Open koop tab
	When  Fill textbox "#autocomplete-input" as "Amsterdam"
	And   Click button ".search-block__body"
	And   Click button ".search-block__submit > button"
	Then  Url path contains "/koop/amsterdam/"

Scenario: Search Anders to Anders
	Given Open koop tab
	When  Click button ".range-filter__input:nth-of-type(1)"
	And   Click button "#range-filter-selector-select-filter_fundakoopprijsvan>option:first-child"
	And   Click button ".range-filter__input:nth-of-type(2)"
	And   Click button "#range-filter-selector-select-filter_fundakoopprijstot>option:first-child"
	And   Click button ".search-block__submit > button"
	Then  Url path contains "/koop/heel-nederland/"

Scenario: Search Maximum to Maximum
	Given Open koop tab
	When  Click button ".range-filter__input:nth-of-type(1)"
	And   Click button "#range-filter-selector-select-filter_fundakoopprijsvan>option:last-child"
	And   Click button ".range-filter__input:nth-of-type(2)"
	And   Click button "#range-filter-selector-select-filter_fundakoopprijstot>option:last-child"
	And   Click button ".search-block__submit > button"
	Then  Url path contains "/koop/heel-nederland/2000000+/"