# PSAppDeployToolkit default rules for PSScriptAnalyser, to ensure compatibility with PowerShell 5.1
@{
    Severity     = @(
        'Error',
        'Warning'
    );
    ExcludeRules = @(
        'PSAlignAssignmentStatement'
    );
    Rules        = @{
        'PSUseCompatibleCmdlets' = @{
            'compatibility' = @('desktop-5.1.14393.206-windows')
        }
    };
}
