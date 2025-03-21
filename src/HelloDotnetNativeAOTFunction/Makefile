build-HelloDotnetNativeAOTFunction:
	# .NET プロジェクトの復元と、SAM の成果物ディレクトリへ publish する
	dotnet publish -c Release -r linux-x64 \
	  -p:GenerateRuntimeConfigurationFiles=true \
	  -p:IntermediateOutputPath=/tmp/dotnet_intermediate/ \
	  -o $(ARTIFACTS_DIR)