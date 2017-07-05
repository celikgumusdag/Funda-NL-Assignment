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

Scenario: Search Koop
	Given Open koop tab
	When  Fill textbox "#autocomplete-input" as "Amsterdam"
	And   Click button ".search-block__body"
	And   Click button ".search-block__submit"
	Then  Url path contains "/koop/amsterdam/"